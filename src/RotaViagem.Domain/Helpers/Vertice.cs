using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RotaViagem.Domain.Helpers
{
    public class Vertice
    {
        private string _id = string.Empty;
        private Dictionary<Vertice, int> adjacencias = new Dictionary<Vertice, int>();
        private int _valor = 0;
        private Boolean _visitado = false;
        private Vertice _verticeAnterior = null;

        public Vertice(string id)
        {
            _id = id;
        }

        public string GetId()
        {
            return _id;
        }

        public void InserirVerticeAdjacente(Vertice para, int peso)
        {
            adjacencias[para] = peso;
        }

        public Dictionary<Vertice, int> GetAdjacentes()
        {
            var dicaux = adjacencias.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return dicaux;
        }

        public void SetValor(int valor)
        {
            _valor = valor;
        }

        public int GetValor()
        {
            return _valor;
        }

        public int GetPeso(Vertice v)
        {
            return adjacencias[v];
        }

        public void SetVisitado(Boolean visitado)
        {
            _visitado = visitado;
        }
        public Boolean GetVisitado()
        {
            return _visitado;
        }

        public void SetVerticeCaminhoAnterior(Vertice v)
        {
            _verticeAnterior = v;
        }

        public Vertice GetVerticeCaminhoAnterior()
        {
            return _verticeAnterior;
        }
    }
}
