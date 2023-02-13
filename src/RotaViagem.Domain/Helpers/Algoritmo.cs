using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RotaViagem.Domain.Helpers
{
    public class Algoritmo
    {
        public static void Dijkstra(Grafo g, Vertice s)
        {
            SortedDictionary<string, Vertice> Q = new SortedDictionary<string, Vertice>();

            InitializeSingleSource(g, s);

            Q = g.GetVertices();

            SortedDictionary<string, Vertice> S = new SortedDictionary<string, Vertice>();

            while (Q.Count > 0)
            {

                Vertice u = ExtractMin(Q);

                u.SetVisitado(true);

                foreach (KeyValuePair<Vertice, int> v in u.GetAdjacentes())
                {
                    if (v.Key.GetVisitado() == true)
                    {
                        continue;
                    }
                    Relax(u, v.Key);
                }
                AddS(u, S);
            }

            /* S tem os pesos finais de caminho mínimos a partir da fonte determinada, assim atualiza o grafo 
             * com os vértices atualizados*/
            g.SetVertices(S);
        }

        public static void InitializeSingleSource(Grafo g, Vertice s)
        {
            foreach (KeyValuePair<string, Vertice> v in g.GetVertices())
            {
                v.Value.SetValor(int.MaxValue);
            }
            s.SetValor(0);
        }

        public static Vertice ExtractMin(SortedDictionary<string, Vertice> Q)
        {
            var key = Q.Keys.ToList()[0];
            Vertice min = Q[key];
            foreach (KeyValuePair<string, Vertice> v in Q)
            {
                if (v.Value.GetValor() < min.GetValor())
                {
                    min = v.Value;
                }
            }
            Q.Remove(min.GetId());
            return min;
        }

        public static void Relax(Vertice u, Vertice v)
        {

            int valor = u.GetValor() + u.GetPeso(v);

            if (v.GetValor() > valor)
            {
                v.SetValor(valor);
                v.SetVerticeCaminhoAnterior(u);
            }
        }

        public static void AddS(Vertice u, SortedDictionary<string, Vertice> S)
        {
            Vertice vertice;
            if (S.TryGetValue(u.GetId(), out vertice))
            {
                vertice = u;
            }
            else
            {
                S.Add(u.GetId(), u);
            }
        }

        public static void CalculaCaminho(Vertice alvo, ArrayList caminho)
        {
            if (caminho.Count == 0)
            {
                caminho.Add(alvo);
            }
            while (alvo.GetVerticeCaminhoAnterior() != null)
            {
                caminho.Add(alvo.GetVerticeCaminhoAnterior());
                alvo = alvo.GetVerticeCaminhoAnterior();
            }
        }

        public static string StringCaminho(ArrayList caminho, Vertice verticeAlvo)
        {
            string ret = "";
            List<string> rota = new List<string>();

            for (int i = caminho.Count - 1; i >= 0; i--)
            {
                Vertice v = (Vertice)caminho[i];
                rota.Add(v.GetId());
            }
            ret = string.Join(" - ", rota.ToArray());
            ret += " ao custo de $" + verticeAlvo.GetValor();

            return ret;
        }
    }
}
