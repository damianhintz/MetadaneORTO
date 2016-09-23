using System;

using OSGeo.OGR;
using MetadaneORTO.Core.Schemat;

namespace MetadaneORTO.Core.Metadane
{
    public class LayerCatalog : IDisposable
    {
        private string _catalogPath = null;

        private Driver _driver = null;

        private DataSource _dataSource = null;

        /// <summary>
        /// Zwraca źródło danych.
        /// </summary>
        public DataSource Source { get { return _dataSource; } }

        LayerSchema _layerSchema = null;

        /// <summary>
        /// Zwraca schemat bazy danych.
        /// </summary>
        public LayerSchema Schema { get { return _layerSchema; } }

        public LayerCatalog(string catalogPath, LayerSchema schema)
        {
            _catalogPath = catalogPath;
            _layerSchema = schema;

            //Ogr.RegisterAll();

            _driver = Ogr.GetDriverByName("ESRI Shapefile");

            if (_driver == null)
                throw new Exception("Nie można użyć sterownika ESRI Shapefile.");

            _dataSource = _driver.CreateDataSource(catalogPath, new string[] { });

            if (_dataSource == null)
                throw new Exception("Nie można utworzyć katalogu metadanych.");
        }

        /// <summary>
        /// Informuje o tym czy warstwa o podanej nazwie już istnieje.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool LayerExists(string name)
        {
            Layer layer = _dataSource.GetLayerByName(name);

            bool exists = false;

            if (layer != null)
            {
                exists = true;
                layer.Dispose();
            }

            return exists;
        }

        /// <summary>
        /// Tworzy nową warstwę metadanych zbudowaną z poligonów.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MetadataLayer CreatePolygonLayer(string name)
        {
            return new MetadataLayer(name, wkbGeometryType.wkbPolygon, this);
        }

        /// <summary>
        /// Tworzy nową warstwę metadanych zbudowaną z punktów.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MetadataLayer CreatePointLayer(string name)
        {
            return new MetadataLayer(name, wkbGeometryType.wkbPoint, this);
        }

        public void Dispose()
        {
            _dataSource.Dispose();
            _driver.Dispose();
        }
    }
}
