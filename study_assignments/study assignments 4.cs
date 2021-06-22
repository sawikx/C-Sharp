using System;
using System.Diagnostics;

namespace projekt_3
{

    class Program
    {
        static Random rnd = new Random();
        #region  metody do sortowania
        #region zadanie 1
        static void InsertionSort(int[] t) // proste wstawianie
        {
            int n = t.Length;
            for (int i = 1; i < n; i++)
            {
                int j = i; // elementy 0 .. i-1 są już posortowane
                int Buf = t[j]; // bierzemy i-ty (j-ty) element
                while ((j > 0) && (t[j - 1] > Buf))
                { // przesuwamy elementy
                    t[j] = t[j - 1];
                    j--;
                }
                t[j] = Buf; // i wpisujemy na docelowe miejsce
            }
        }
        static void SelectionSort(int[] t) // proste wybieranie
        {
            int n = t.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int Buf = t[i];   // bierzemy i-ty element
                int k = i;        // i jego indeks
                for (int j = i + 1; j < n; j++)
                {
                    if (t[j] < Buf) // szukamy najmniejszego z prawej
                    {
                        k = j;
                        Buf = t[j];
                    }
                }
                t[k] = t[i];   // zamieniamy i-ty z k-tym
                t[i] = Buf;
            }
        }
        static void Heapify(int[] t, uint left, uint right)
        { // procedura budowania/naprawiania kopca
            uint i = left,
            j = 2 * i + 1;
            int buf = t[i]; // ojciec

            while (j <= right) // przesiewamy do dna stogu
            {
                if (j < right) // wybieramy większego syna
                    if (t[j] < t[j + 1]) j++;
                if (buf >= t[j]) break;
                t[i] = t[j];
                i = j;
                j = 2 * i + 1; // przechodzimy do dzieci syna
            }

            t[i] = buf;
        }
        //---------------

        static void HeapSort(int[] t)
        {
            uint left = (uint)t.Length / 2;
            uint right = (uint)t.Length - 1;

            while (left > 0) // budujemy kopiec idąc od połowy tablicy
            {
                left--;
                Heapify(t, left, right);
            }

            while (right > 0) // rozbieramy kopiec
            {
                int buf = t[left];
                t[left] = t[right];
                t[right] = buf; // największy element
                right--; // kopiec jest mniejszy
                Heapify(t, left, right); // ale trzeba go naprawić
            }
        }
        static void CocktailSort(int[] t) // koktailowe
        {
            int n = t.Length;
            int Left = 1;
            int Right = n - 1;
            int k = n - 1;

            do
            {
                for (int j = Right; j >= Left; j--) // przesiewanie od dołu
                {
                    if (t[j - 1] > t[j])
                    {
                        int Buf = t[j - 1]; t[j - 1] = t[j]; t[j] = Buf;
                        k = j; // zamiana elementów i zapamiętanie indeksu
                    }
                }
                Left = k + 1; // zacieśnienie lewej granicy
                for (int j = Left; j <= Right; j++) // przesiewanie od góry
                {
                    if (t[j - 1] > t[j])
                    {
                        int Buf = t[j - 1]; t[j - 1] = t[j]; t[j] = Buf;
                        k = j; // zamiana elementów i zapamiętanie indeksu
                    }
                }
                Right = k - 1; // zacieśnienie prawej granicy
            }
            while (Left <= Right);
        }
        #endregion
        #region zadanie 2
        static void QSortReqp(int[] T)
        {
            QSortHelpp(T, 0, T.Length - 1);
        }
        static void QSortHelpp(int[] t, int l, int p)
        {
            int i, j, x;
            i = l;
            j = p;
            x = t[p]; // (pseudo)mediana
            do
            {
                while (t[i] < x) i++; // przesuwamy indeksy z lewej
                while (x < t[j]) j--; // przesuwamy indeksy z prawej
                if (i <= j) // jeśli nie minęliśmy się indeksami (koniec kroku)
                { // zamieniamy elementy
                    int buf = t[i]; t[i] = t[j]; t[j] = buf;
                    i++; j--;
                }
            }
            while (i <= j);

            if (l < j) QSortHelpp(t, l, j); // sortujemy lewą część (jeśli jest)
            if (i < p) QSortHelpp(t, i, p); // sortujemy prawą część (jeśli jest)
        }
        static void QSortIterp(int[] t)
        {
            int i, j, l, p, sp;
            int[] stos_l = new int[t.Length],
            stos_p = new int[t.Length]; // przechowywanie żądań podziału
            sp = 0; stos_l[sp] = 0; stos_p[sp] = t.Length - 1; // rozpoczynamy od całej tablicy

            do
            {
                l = stos_l[sp]; p = stos_p[sp]; sp--; // pobieramy żądanie podziału
                do
                {
                    int x;
                    i = l; j = p; x = t[p]; // analogicznie do wersji rekurencyjnej
                    do
                    {
                        while (t[i] < x) i++;
                        while (x < t[j]) j--;
                        if (i <= j)
                        {
                            int buf = t[i]; t[i] = t[j]; t[j] = buf;
                            i++; j--;
                        }
                    } while (i <= j);

                    if (i < p) { sp++; stos_l[sp] = i; stos_p[sp] = p; } // ewentualnie dodajemy żądanie podziału
                    p = j;
                } while (l < p);
            } while (sp >= 0); // dopóki stos żądań nie będzie pusty
        }
        static void QSortReqs(int[] T)
        {
            QSortHelps(T, 0, T.Length - 1);
        } 
        static void QSortHelps(int[] t, int l, int p)
        {
            int i, j, x;
            i = l;
            j = p;
            x = t[(l + p) / 2]; // (pseudo)mediana
            do
            {
                while (t[i] < x) i++; // przesuwamy indeksy z lewej
                while (x < t[j]) j--; // przesuwamy indeksy z prawej
                if (i <= j) // jeśli nie minęliśmy się indeksami (koniec kroku)
                { // zamieniamy elementy
                    int buf = t[i]; t[i] = t[j]; t[j] = buf;
                    i++; j--;
                }
            }
            while (i <= j);

            if (l < j) QSortHelps(t, l, j); // sortujemy lewą część (jeśli jest)
            if (i < p) QSortHelps(t, i, p); // sortujemy prawą część (jeśli jest)
        }
        static void QSortIters(int[] t)
        {
            int i, j, l, p, sp;
            int[] stos_l = new int[t.Length],
            stos_p = new int[t.Length]; // przechowywanie żądań podziału
            sp = 0; stos_l[sp] = 0; stos_p[sp] = t.Length - 1; // rozpoczynamy od całej tablicy

            do
            {
                l = stos_l[sp]; p = stos_p[sp]; sp--; // pobieramy żądanie podziału
                do
                {
                    int x;
                    i = l; j = p; x = t[(l + p) / 2]; // analogicznie do wersji rekurencyjnej
                    do
                    {
                        while (t[i] < x) i++;
                        while (x < t[j]) j--;
                        if (i <= j)
                        {
                            int buf = t[i]; t[i] = t[j]; t[j] = buf;
                            i++; j--;
                        }
                    } while (i <= j);

                    if (i < p) { sp++; stos_l[sp] = i; stos_p[sp] = p; } // ewentualnie dodajemy żądanie podziału
                    p = j;
                } while (l < p);
            } while (sp >= 0); // dopóki stos żądań nie będzie pusty
        }
        static void QSortReql(int[] T)
        {
            QSortHelpl(T, 0, T.Length - 1);
        }
        static void QSortHelpl(int[] t, int l, int p)
        {
            int i, j, x;
            i = l;
            j = p;
            x = t[rnd.Next(l,p+1)]; // (pseudo)mediana
            do
            {
                while (t[i] < x) i++; // przesuwamy indeksy z lewej
                while (x < t[j]) j--; // przesuwamy indeksy z prawej
                if (i <= j) // jeśli nie minęliśmy się indeksami (koniec kroku)
                { // zamieniamy elementy
                    int buf = t[i]; t[i] = t[j]; t[j] = buf;
                    i++; j--;
                }
            }
            while (i <= j);

            if (l < j) QSortHelpl(t, l, j); // sortujemy lewą część (jeśli jest)
            if (i < p) QSortHelpl(t, i, p); // sortujemy prawą część (jeśli jest)
        }
        static void QSortIterl(int[] t)
        {
            int i, j, l, p, sp;
            int[] stos_l = new int[t.Length],
            stos_p = new int[t.Length]; // przechowywanie żądań podziału
            sp = 0; stos_l[sp] = 0; stos_p[sp] = t.Length - 1; // rozpoczynamy od całej tablicy

            do
            {
                l = stos_l[sp]; p = stos_p[sp]; sp--; // pobieramy żądanie podziału
                do
                {
                    int x;
                    i = l; j = p; x = t[rnd.Next(l, p + 1)]; // analogicznie do wersji rekurencyjnej
                    do
                    {
                        while (t[i] < x) i++;
                        while (x < t[j]) j--;
                        if (i <= j)
                        {
                            int buf = t[i]; t[i] = t[j]; t[j] = buf;
                            i++; j--;
                        }
                    } while (i <= j);

                    if (i < p) { sp++; stos_l[sp] = i; stos_p[sp] = p; } // ewentualnie dodajemy żądanie podziału
                    p = j;
                } while (l < p);
            } while (sp >= 0); // dopóki stos żądań nie będzie pusty
        }
        #endregion
        #endregion
        #region generowanie tablic        
        static bool GenRozkladRosnacy(int[] T, int i0, int n, int N1, int N2, Random rnd)
        {
            if (N2 <= N1) return false;
            if (i0 < 0 || i0 + n > T.Length) return false;

            int d = (N2 - N1 + 1) / n;

            if (d < 1) return false;

            int p1 = N1;
            int p2 = N1 + d - 1;
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1) p2 = N2;

                T[i0 + i] = rnd.Next(p1, p2 + 1);
                p1 += d;
                p2 += d;
            }

            return true;
        }
        static bool GenRozkladRosnacy(int[] T, int N1, int N2, Random rnd)
        {
            if (N2 <= N1) return false;
            int n = T.Length;
            int d = (N2 - N1 + 1) / n;

            if (d < 1) return false;

            int p1 = N1;
            int p2 = N1 + d - 1;
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1) p2 = N2;
                // Console.WriteLine("{0}, {1}", p1, p2);   

                T[i] = rnd.Next(p1, p2 + 1);
                p1 += d;
                p2 += d;
            }

            return true;
        }
        static void Odwroc(int[] T)
        {
            int n = T.Length;
            int m = n / 2;
            for (int i = 0; i < m; i++)
            {
                int buf = T[i];
                T[i] = T[n - 1 - i];
                T[n - 1 - i] = buf;
            }
        }
        static bool Odwroc(int[] T, int i0, int n)
        {
            if (i0 < 0 || i0 + n > T.Length) return false;

            int m = n / 2;
            for (int i = 0; i < m; i++)
            {
                int buf = T[i0 + i];
                T[i0 + i] = T[i0 + n - 1 - i];
                T[i0 + n - 1 - i] = buf;
            }

            return true;
        }
        static bool GenRozkladMalejacy(int[] T, int N1, int N2, Random rnd)
        {
            bool res = GenRozkladRosnacy(T, N1, N2, rnd);
            if (!res) return false;

            //Array.Reverse(T);
            Odwroc(T);
            return true;
        }
        static bool GenRozkladMalejacy(int[] T, int i0, int n, int N1, int N2, Random rnd)
        {
            bool res = GenRozkladRosnacy(T, i0, n, N1, N2, rnd);
            if (!res) return false;

            if (!Odwroc(T, i0, n)) return false;
            return true;
        }
        static bool GenRozkladV(int[] T, int N1, int N2, Random rnd)
        {
            int n = T.Length;
            int m = n / 2;

            bool res = GenRozkladMalejacy(T, 0, m, N1, N2, rnd);
            if (!res) return false;

            res = GenRozkladRosnacy(T, m, n - m, N1, N2, rnd);
            return res;
        }
        static bool GenRozkladA(int[] T, int N1, int N2, Random rnd)
        {
            int n = T.Length;
            int m = n / 2;

            bool res = GenRozkladRosnacy(T, 0, m, N1, N2, rnd);
            if (!res) return false;

            res = GenRozkladMalejacy(T, m, n - m, N1, N2, rnd);
            return res;
        }
        #endregion
        static void Main(string[] args)
        {            
            Stopwatch st = new Stopwatch();
            #region zadanie 1
            for (int N=50000;N<=200000;N+= 50000)
            {                
                int los = rnd.Next(0, N + 1);
                int[] A = new int[N];
                int[] B = new int[N];
                int[] C = new int[N];
                int[] D = new int[N];
                int[] E = new int[N];
                long[,] czas = new long[4, 5];


                for (int i = 0; i < N; i++)//Losowa tablica
                {
                    A[i] = rnd.Next(0, N + 1);
                }
                if (!GenRozkladRosnacy(B, 0, N, rnd)) { Console.WriteLine("Error.."); return; }
                if (!GenRozkladMalejacy(C, 0, N, rnd)) { Console.WriteLine("Error.."); return; }
                for (int i = 0; i < N; i++)//stała ablica
                {
                    D[i] = los;
                }
                if (!GenRozkladV(E, 0, N, rnd)) { Console.WriteLine("Error.."); return; }

                st.Start();
                InsertionSort(A);
                st.Stop();
                czas[0, 0] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                InsertionSort(B);
                st.Stop();
                czas[0, 1] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                InsertionSort(C);
                st.Stop();
                czas[0, 2] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                InsertionSort(D);
                st.Stop();
                czas[0, 3] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                InsertionSort(E);
                st.Stop();
                czas[0, 4] = st.ElapsedMilliseconds;
                st.Reset();

                for (int i = 0; i < N; i++)//Losowa tablica
                {
                    A[i] = rnd.Next(0, N + 1);
                }
                if (!GenRozkladRosnacy(B, 0, N, rnd)) { Console.WriteLine("Error.."); return; }
                if (!GenRozkladMalejacy(C, 0, N, rnd)) { Console.WriteLine("Error.."); return; }
                for (int i = 0; i < N; i++)//stała ablica
                {
                    D[i] = los;
                }
                if (!GenRozkladV(E, 0, N, rnd)) { Console.WriteLine("Error.."); return; }

                st.Start();
                SelectionSort(A);
                st.Stop();
                czas[1, 0] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                SelectionSort(B);
                st.Stop();
                czas[1, 1] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                SelectionSort(C);
                st.Stop();
                czas[1, 2] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                SelectionSort(D);
                st.Stop();
                czas[1, 3] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                SelectionSort(E);
                st.Stop();
                czas[1, 4] = st.ElapsedMilliseconds;
                st.Reset();

                for (int i = 0; i < N; i++)//Losowa tablica
                {
                    A[i] = rnd.Next(0, N + 1);
                }
                if (!GenRozkladRosnacy(B, 0, N, rnd)) { Console.WriteLine("Error.."); return; }
                if (!GenRozkladMalejacy(C, 0, N, rnd)) { Console.WriteLine("Error.."); return; }
                for (int i = 0; i < N; i++)//stała ablica
                {
                    D[i] = los;
                }
                if (!GenRozkladV(E, 0, N, rnd)) { Console.WriteLine("Error.."); return; }

                st.Start();
                HeapSort(A);
                st.Stop();
                czas[2, 0] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                HeapSort(B);
                st.Stop();
                czas[2, 1] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                HeapSort(C);
                st.Stop();
                czas[2, 2] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                HeapSort(D);
                st.Stop();
                czas[2, 3] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                HeapSort(E);
                st.Stop();
                czas[2, 4] = st.ElapsedMilliseconds;
                st.Reset();

                for (int i = 0; i < N; i++)//Losowa tablica
                {
                    A[i] = rnd.Next(0, N + 1);
                }
                if (!GenRozkladRosnacy(B, 0, N, rnd)) { Console.WriteLine("Error.."); return; }
                if (!GenRozkladMalejacy(C, 0, N, rnd)) { Console.WriteLine("Error.."); return; }
                for (int i = 0; i < N; i++)//stała ablica
                {
                    D[i] = los;
                }
                if (!GenRozkladV(E, 0, N, rnd)) { Console.WriteLine("Error.."); return; }

                st.Start();
                CocktailSort(A);
                st.Stop();
                czas[3, 0] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                CocktailSort(B);
                st.Stop();
                czas[3, 1] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                CocktailSort(C);
                st.Stop();
                czas[3, 2] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                CocktailSort(D);
                st.Stop();
                czas[3, 3] = st.ElapsedMilliseconds;
                st.Reset();
                st.Start();
                CocktailSort(E);
                st.Stop();
                czas[3, 4] = st.ElapsedMilliseconds;
                st.Reset();
                string[] msort = new string[] { "Insertion Sort", "Selection Sort", "Heap Sort", "Cocktail Sort" };
                Console.WriteLine("Metod sortowania\tlosowej\t rosnącej\t malejącej\t stałej\t v‐kształtnej");
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("{5}\t\t{0}\t {1}\t\t {2}\t\t {3}\t {4}", czas[i, 0], czas[i, 1], czas[i, 2], czas[i, 3], czas[i, 4], msort[i]);
                }
                Console.WriteLine("");
            }
            #endregion
            #region zadanie 2
            #region A
            int liczbamax = 200000;
            int[] table = new int[liczbamax];
            long[] czasy = new long[30];
            for (int qwer=0; qwer < 15; qwer++) {
                for (int i = 0; i < liczbamax; i++)//Losowa tablica
                {
                    table[i] = rnd.Next(0, liczbamax + 1);
                }
                st.Start();
                QSortReqs(table);
                st.Stop();
                czasy[0] = st.ElapsedMilliseconds;
                st.Reset();
                for (int i = 0; i < liczbamax; i++)//Losowa tablica
                {
                    table[i] = rnd.Next(0, liczbamax + 1);
                }
                st.Start();
                QSortIters(table);
                st.Stop();
                czasy[1] = st.ElapsedMilliseconds;
                st.Reset();
                Console.WriteLine("Req = {0}  Iter = {1}", czasy[0], czasy[1]);
            }
            #endregion
            #region B
            liczbamax = 2000000000;
            Console.WriteLine("Rekurencyjnie klucz: skrajnie prawego | środkowego co do położenia | losowo wybranego\titeracyjny klucz: skrajnie prawego | środkowego co do położenia | losowo wybranego");
            for (int qwer=0; qwer<30; qwer+=6)
            {
                if(!GenRozkladA(table, 0, liczbamax, rnd)) { Console.WriteLine("Error.."); return; }
                st.Start();
                QSortReqp(table);
                st.Stop();
                czasy[qwer] = st.ElapsedMilliseconds;
                st.Reset();
                if (!GenRozkladA(table, 0, liczbamax, rnd)) { Console.WriteLine("Error.."); return; }
                st.Start();
                QSortReqs(table);
                st.Stop();
                czasy[1+ qwer] = st.ElapsedMilliseconds;
                st.Reset();
                if (!GenRozkladA(table, 0, liczbamax, rnd)) { Console.WriteLine("Error.."); return; }
                st.Start();
                QSortReql(table);
                st.Stop();
                czasy[2+ qwer] = st.ElapsedMilliseconds;
                st.Reset();
                if (!GenRozkladA(table, 0, liczbamax, rnd)) { Console.WriteLine("Error.."); return; }
                st.Start();
                QSortIterp(table);
                st.Stop();
                czasy[3+ qwer] = st.ElapsedMilliseconds;
                st.Reset();
                if (!GenRozkladA(table, 0, liczbamax, rnd)) { Console.WriteLine("Error.."); return; }
                st.Start();
                QSortIters(table);
                st.Stop();
                czasy[4+ qwer] = st.ElapsedMilliseconds;
                st.Reset();
                if (!GenRozkladA(table, 0, liczbamax, rnd)) { Console.WriteLine("Error.."); return; }
                st.Start();
                QSortIterl(table);
                st.Stop();
                czasy[5+ qwer] = st.ElapsedMilliseconds;
                st.Reset();
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", czasy[qwer], czasy[1 + qwer], czasy[2 + qwer], czasy[3 + qwer], czasy[4 + qwer], czasy[5 + qwer]);
            }
            #endregion
            #endregion
        }
    }
}
