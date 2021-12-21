using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilteringApp.Core.Utils
{
    public static class ArrayMergeSort
    {
        public static void MergeInPlace(int[] a, int l, int m, int r)
        {
            {
                int mx = Math.Max(a[m], a[r]) + 1;
                int i = l, j = m + 1, k = l;
                while (i <= m && j <= r && k <= r)
                {
                    int e1 = a[i] % mx;
                    int e2 = a[j] % mx;
                    if (e1 <= e2)
                    {
                        a[k] += (e1 * mx);
                        i++;
                        k++;
                    }
                    else
                    {
                        a[k] += (e2 * mx);
                        j++;
                        k++;
                    }
                }

                while (i <= m)
                {
                    int el = a[i] % mx;
                    a[k] += (el * mx);
                    i++;
                    k++;
                }

                while (j <= r)
                {
                    int el = a[j] % mx;
                    a[k] += (el * mx);
                    j++;
                    k++;
                }

                for (int i2 = l; i2 <= r; i2++)
                {
                    a[i] /= mx;
                }
            }
        }

        public static void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                MergeInPlace(arr, l, m, r);
            }
        }
    }
}
