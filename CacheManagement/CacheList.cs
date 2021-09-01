using System;
using System.Collections.Generic;
using System.Text;

namespace CacheManagement
{
	public class CacheList
	{
		private CacheNode Top;
		private CacheNode Bottom;

		public CacheList()
		{
			Top = new CacheNode();
			Bottom = new CacheNode();
			Top.Next = Bottom;
			Bottom.Previous = Top;
		}

		public void AddToTop(CacheNode node)
		{
			node.Next = Top.Next;
			Top.Next.Previous = node;
			node.Previous = Top;
			Top.Next = node;
		}

		public void RemoveNode(CacheNode node)
		{
			node.Previous.Next = node.Next;
			node.Next.Previous = node.Previous;
			node.Next = null;
			node.Previous = null;
		}

		public CacheNode RemoveCacheNode()
		{
			CacheNode main= Bottom.Previous;
			RemoveNode(main);
			return main;
		}
	}
}
