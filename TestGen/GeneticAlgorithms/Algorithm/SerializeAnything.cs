using System;
using System.Runtime.InteropServices;

namespace TestGen.GeneticAlgorithms
{
    public class SerializeAnything
	{
		// 9/28/2002
		// NETMaster (Thomas Scheidegger)
		//	http://www.cetus-links.org/oo_csharp.html
		// ===============================================================
		public static object RawDeserializeEx( byte[] rawdatas, Type anytype, int rawsize)
		{
			GCHandle handle = GCHandle.Alloc( rawdatas, GCHandleType.Pinned );
			IntPtr buffer = handle.AddrOfPinnedObject();
			object retobj = Marshal.PtrToStructure( buffer, anytype );
			handle.Free();
			return retobj;
		}
		public static byte[] RawSerializeEx(object anything, int rawsize)
		{
			byte[] rawdatas = new byte[ rawsize ];
			GCHandle handle = GCHandle.Alloc( rawdatas, GCHandleType.Pinned );
			IntPtr buffer = handle.AddrOfPinnedObject();
			Marshal.StructureToPtr( anything, buffer, false );
			handle.Free();
			return rawdatas;
		}
	}
}
// ===============================================================



