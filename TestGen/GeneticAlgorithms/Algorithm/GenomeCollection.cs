using System.Collections;

namespace TestGen.GeneticAlgorithms
{
    public class GenomeCollection: System.Collections.CollectionBase
	{
		public GenomeCollection()
		{

        }
		public GenomeCollection(Genome[] items)
		{
			this.AddRange(items);
		}
		public GenomeCollection(GenomeCollection items)
		{
			this.AddRange(items);
		}
		public virtual void AddRange(Genome[] items)
		{
			foreach (Genome item in items)
			{
				this.List.Add(item);
			}
		}
		public virtual void AddRange(GenomeCollection items)
		{
			foreach (Genome item in items)
			{
				this.List.Add(item);
			}
		}
        public virtual void RemoveNext(int initial, int num)
        {
            for(int i=0;i<num;i++)
                this.List.RemoveAt(initial);
        }
        public virtual void Add(Genome value)
		{
			this.List.Add(value);
		}
		public virtual bool Contains(Genome value)
		{
			return this.List.Contains(value);
		}
		public virtual int IndexOf(Genome value)
		{
			return this.List.IndexOf(value);
		}
		public virtual void Insert(int index, Genome value)
		{
			this.List.Insert(index, value);
		}
		public virtual Genome this[int index]
		{
			get { return (Genome) this.List[index]; }
			set { this.List[index] = value; }
		}
		public virtual void Remove(Genome value)
		{
			this.List.Remove(value);
		}
		public class Enumerator: System.Collections.IEnumerator
		{
			private System.Collections.IEnumerator wrapped;

			public Enumerator(GenomeCollection collection)
			{
				this.wrapped = ((System.Collections.CollectionBase)collection).GetEnumerator();
			}
			public Genome Current
			{
				get { return (Genome) (this.wrapped.Current); }
			}
			object System.Collections.IEnumerator.Current
			{
				get { return (Genome) (this.wrapped.Current); }
			}
			public bool MoveNext()
			{
				return this.wrapped.MoveNext();
			}
			public void Reset()
			{
				this.wrapped.Reset();
			}
		}
		public new virtual GenomeCollection.Enumerator GetEnumerator()
		{
			return new GenomeCollection.Enumerator(this);
		}
		#region Sorting Methods
		public void Sort()
		{
			InnerList.Sort();			
		}
		public void Sort(IComparer comparer)
		{
			InnerList.Sort(comparer);
		}
		public void Sort(int index, int count, IComparer comparer)
		{
			InnerList.Sort(index, count, comparer);
		}
		#endregion
	}
}
