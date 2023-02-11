using System;
using System.Collections.Generic;
using System.Text;

namespace RotaViagem.Domain.Helpers
{
    public class Grafo
    {
        private SortedDictionary<string, Vertice> vertices = new SortedDictionary<string, Vertice>();
        private Boolean _direcionado = false;

        public Grafo(Boolean direcionado)
        {
            _direcionado = direcionado;
        }

        public void InserirVertice(string id)
        {
            Vertice v = new Vertice(id);
            vertices[id] = v;
        }

        public void InserirAresta(string de, string para, int peso)
        {
            Vertice p = vertices[para];
            Vertice d = vertices[de];
            vertices[de].InserirVerticeAdjacente(p, peso);
            if (!_direcionado)
            {
                vertices[para].InserirVerticeAdjacente(d, peso);
            }
        }

        public Vertice GetVertice(string vertice)
        {
            if (vertices.ContainsKey(vertice))
            {
                return vertices[vertice];
            }
            else
            {
                return null;
            }
        }
        public SortedDictionary<string, Vertice> GetVertices()
        {
            return vertices;
        }

        public void SetVertices(SortedDictionary<string, Vertice> vs)
        {
            vertices = vs;
        }
    }
}
