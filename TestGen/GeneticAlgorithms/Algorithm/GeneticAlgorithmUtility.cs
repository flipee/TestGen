using System;

namespace TestGen.GeneticAlgorithms
{
    public sealed class GeneticAlgorithmUtility
	{
        private static Random randomProvider = new Random();

		#region Random Methods
		public static byte[] GetRandomBytes(int size)
		{
			byte[] buffer=new byte[size];
			RandomProvider.NextBytes(buffer);
			return buffer;
		}
		public static Random RandomProvider
		{
			get { return randomProvider; }
			set { randomProvider=value; }
		}
		#endregion
	}
}



