using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

// this list's purpose is to give direct access to the internal array when needed
public sealed class FlinqList<T> : IDisposable
{
	internal T[] array;
	internal int count;

	private const int InitialCapacity = 8;

	internal int Capacity { get { return array.Length; } }

	// for non-internal use only! //
	public T this[int index] { get { return array[index]; } }
	public int Count { get { return count; } }
	////////////////////////////////

	internal FlinqList()
	{
		array = new T[InitialCapacity];
	}

	internal void Add(T elem)
	{
		EnsureCapacity(count + 1);

		array[count++] = elem;
	}

	internal void Prepend(T elem)
	{
		EnsureCapacity(count + 1);

		Array.Copy(array, 0, array, 1, count);

		array[0] = elem;
	}

	internal void AddRange(FlinqList<T> list)
	{
		int listCount = list.count;

		EnsureCapacity(count + listCount);

		Array.Copy(list.array, 0, array, count, listCount);

		count += listCount;
	}

	internal void RemoveAt(int index)
	{
		--count;

		if(index < count)
			Array.Copy(array, index + 1, array, index, count - index);
	}

	internal void RemoveRange(int index, int removeCount)
	{
		if(removeCount > 0)
		{
			count -= removeCount;

			if(index < count)
				Array.Copy(array, index + removeCount, array, index, count - index);
		}
	}

	internal void Clear()
	{
		count = 0;
	}

	internal void Reverse()
	{
		int i = 0;
		int j = count - 1;

		while(i < j)
		{
			var temp = array[i];
			array[i] = array[j];
			array[j] = temp;

			++i;
			--j;
		}
	}

	internal void Sort<TKey>(FlinqList<TKey> keys)
	{
		throw new NotImplementedException();
	}

	internal void SortDescending<TKey>(FlinqList<TKey> keys)
	{
		throw new NotImplementedException();
	}

	internal void CopyFrom(List<T> list)
	{
		int listCount = list.Count;

		EnsureCapacity(listCount);

		list.CopyTo(array, 0);

		count = listCount;
	}

	internal void CopyFrom(T[] arr)
	{
		int arrLength = arr.Length;

		EnsureCapacity(arrLength);

		Array.Copy(arr, array, arrLength);

		count = arrLength;
	}

	internal void CopyFrom(FlinqList<T> list)
	{
		int listCount = list.count;

		EnsureCapacity(listCount);
		
		Array.Copy(list.array, 0, array, 0, listCount);

		count = listCount;
	}

	internal void CopyFrom(ICollection<T> collection)
	{
		int collectionCount = collection.Count;

		EnsureCapacity(collectionCount);

		collection.CopyTo(array, 0);

		count = collectionCount;
	}

	internal void CopyFrom(IEnumerable<T> enumerable)
	{
		var collection = enumerable as ICollection<T>;

		if(collection != null)
			CopyFrom(collection);
		else
		{
			Clear();

			foreach(var elem in enumerable)
			{
				Add(elem);
			}
		}
	}

	internal void CopyFrom<TKey>(Dictionary<TKey, T> dictionary)
	{
		EnsureCapacity(dictionary.Count);

		count = 0;

		foreach(var elem in dictionary)
		{
			array[count] = elem.Value;
			++count;
		}
	}

	internal bool Exists(Predicate<T> predicate)
	{
		return FindIndex(predicate) != -1;
	}

	internal T Find(Predicate<T> predicate)
	{
		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			if(predicate(elem))
				return elem;
		}

		return default(T);
	}

	internal int FindIndex(Predicate<T> predicate)
	{
		return FindIndex(0, predicate);
	}

	internal int FindIndex(int startFrom, Predicate<T> predicate)
	{
		for(int i = startFrom; i < count; ++i)
		{
			var elem = array[i];

			if(predicate(elem))
				return i;
		}

		return -1;
	}

	internal T FindLast(Predicate<T> predicate)
	{
		for(int i = count; i >= 0; --i)
		{
			var elem = array[i];

			if(predicate(elem))
				return elem;
		}

		return default(T);
	}

	internal int FindLastIndex(Predicate<T> predicate)
	{
		return FindLastIndex(count - 1, predicate);
	}

	internal int FindLastIndex(int startFrom, Predicate<T> predicate)
	{
		for(int i = startFrom; i >= 0; --i)
		{
			var elem = array[i];

			if(predicate(elem))
				return i;
		}

		return -1;
	}

	internal bool Contains(T elem)
	{
		var comparer = EqualityComparer<T>.Default;

		for(int i = 0; i < count; ++i)
		{
			if(comparer.Equals(array[i], elem))
				return true;
		}

		return false;
	}

	internal bool TrueForAll(Predicate<T> predicate)
	{
		for(int i = 0; i < count; ++i)
		{
			if(!predicate(array[i]))
				return false;
		}

		return true;
	}

	internal void KeepWhere(Predicate<T> predicate)
	{
		int free = 0;

		while(free < count && predicate(array[free]))
		{
			free++;
		}

		if(free >= count)
			return;

		int index = free + 1;

		while(index < count)
		{
			while(index < count && !predicate(array[index]))
			{
				index++;
			}

			if(index < count)
				array[free++] = array[index++];
		}

		count = free;
	}

	internal void KeepWhere(Func<T, int, bool> predicate)
	{
		int free = 0;

		while(free < count && predicate(array[free], free))
		{
			free++;
		}

		if(free >= count)
			return;

		int index = free + 1;

		while(index < count)
		{
			while(index < count && !predicate(array[index], index))
			{
				index++;
			}

			if(index < count)
				array[free++] = array[index++];
		}

		count = free;
	}

	internal void KeepWhereHashSetContains(HashSet<T> hashSet)
	{
		int free = 0;

		while(free < count && hashSet.Contains(array[free]))
		{
			free++;
		}

		if(free >= count)
			return;

		int index = free + 1;

		while(index < count)
		{
			while(index < count && !hashSet.Contains(array[index]))
			{
				index++;
			}

			if(index < count)
				array[free++] = array[index++];
		}

		count = free;
	}

	internal void RemoveWhereHashSetContains(HashSet<T> hashSet)
	{
		int free = 0;

		while(free < count && !hashSet.Contains(array[free]))
		{
			free++;
		}

		if(free >= count)
			return;

		int index = free + 1;

		while(index < count)
		{
			while(index < count && hashSet.Contains(array[index]))
			{
				index++;
			}

			if(index < count)
				array[free++] = array[index++];
		}

		count = free;
	}

	public void Dispose()
	{
		FlinqListPool<T>.Return(this);
	}

	private void EnsureCapacity(int size)
	{
		int capacity = array.Length;
		int initialCapacity = capacity;

		while(capacity < size)
		{
			capacity *= 2;
		}

		if(capacity != initialCapacity)
		{
			var newArray = new T[capacity];
			Array.Copy(array, 0, newArray, 0, count);
			array = newArray;
		}
	}
}

}
