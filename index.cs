// Chapter - Basic Structures: Sets, Functions, Sequences, Sums, and Matrices

// Given a finite set, list all elements of its power set.


// Per te ekzekutuar kodin duhet te keni te instaluar Microsoft .NET 8.0 Framework SDK, permes komandes "dotnet run PowerSet.cs" ne cmd
// ose mund ta kopjoni dhe ta ekzekutoni ne csharp online compilers si: https://www.programiz.com/csharp-programming/online-compiler/


using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace MathProject
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Enter elements of the set (separated by comma): ");
			Set<string> set = new Set<string>(Console.ReadLine().Split(",").ToArray());
			set.PowerSet();
		}
	}



	// Permes klases Set behet krijimi i bashkesise
    public class Set<E>
	{
		private ISet<E> set;

		public Set(params E[] elements)
		{
			this.set = new HashSet<E>(elements);
		}

		public Set() : this(new E[0]) { }

		// Metoda per te paraqitur te gjitha nenbashkesite e bashkesise se dhene
		public void PowerSet()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("Set A = {0}\n\nP(A) = {{{{∅}}, ", ToString());

			// krijohet nje varg me elementet e bashkesise per te lehtesuar printimin e nenbashkesive
			E[] elements = set.ToArray();

			AddSubsetsToPrint(elements, sb);

			sb.Length = sb.Length - 2;
			sb.Append('}');

			Console.WriteLine(sb.ToString());
		}

		// Metoda e cila fillon printimin e nenbashkesive prej atyre me 1 element deri ne n elemente
		private void AddSubsetsToPrint(E[] elements, StringBuilder sb)
		{
			E[] subsetElements;
			for (int size = 1; size <= elements.Length; size++)
			{
				subsetElements = new E[size];
				AddSubsetsToPrint(elements, subsetElements, 0, elements.Length, 0, size, sb);
			}
		}

		// Metode rekurzive e cila printon cdo nenbashkesi me n elemente duke nga nje element prej nenbashkesise ne cdo cikel
		private void AddSubsetsToPrint(E[] elements, E[] subsetElements, int start, int end, int index, int size, StringBuilder sb)
		{
			if (index == size)
			{
				Set<E> subset = new Set<E>(subsetElements);
				sb.Append(subset.ToString());
				sb.Append(", ");
				return;
			}

			for (int i = start; i < end && end - i >= size - index; i++)
			{
				subsetElements[index] = elements[i];
				AddSubsetsToPrint(elements, subsetElements, i + 1, end, index + 1, size, sb);
			}
		}


		// Permes metodes Add mund te shtohen elemente ne bashkesi.
		public void Add(E element)
		{
			set.Add(element);
		}

		// Metode e cila ben reprezentimin e bashkesise, duke i paraqitur te gjitha elementet.
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			if (set.Count == 0)
				return "{∅}";

			sb.Append('{');

			foreach (E element in set)
			{
				sb.Append(element);
				sb.Append(", ");
			}

			sb.Length = sb.Length - 2;
			sb.Append('}');

			return sb.ToString();
		}
	}
}