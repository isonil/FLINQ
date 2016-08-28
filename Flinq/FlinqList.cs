using System;
using System.Collections.Generic;

namespace Flinq
{

// this list's purpose is to give direct access to the internal array when needed
public sealed class FlinqList<T>
{
	internal T[] array;
	internal int count;

	private const int InitialCapacity = 8;

	public int Capacity { get { return array.Length; } }

	public FlinqList()
	{
		array = new T[InitialCapacity];
	}

	public void Add(T elem)
	{
		EnsureCapacity(count + 1);

		array[count++] = elem;
	}

	public void Prepend(T elem)
	{
		EnsureCapacity(count + 1);

		Array.Copy(array, 0, array, 1, count);

		array[0] = elem;
	}

	public void AddRange(FlinqList<T> list)
	{
		int listCount = list.count;

		EnsureCapacity(count + listCount);

		Array.Copy(list.array, 0, array, count, listCount);

		count += listCount;
	}

	public void RemoveAt(int index)
	{
		--count;

		if(index < count)
			Array.Copy(array, index + 1, array, index, count - index);
	}

	public void RemoveRange(int index, int removeCount)
	{
		if(removeCount > 0)
		{
			count -= removeCount;

			if(index < count)
				Array.Copy(array, index + removeCount, array, index, count - index);
		}
	}

	public void Clear()
	{
		count = 0;
	}

	public void Reverse()
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

	public void Sort<TKey>(FlinqList<TKey> keys)
	{
		throw new NotImplementedException();
	}

	public void SortDescending<TKey>(FlinqList<TKey> keys)
	{
		throw new NotImplementedException();
	}

	public void CopyFrom(List<T> list)
	{
		int listCount = list.Count;

		EnsureCapacity(listCount);

		list.CopyTo(array, 0);

		count = listCount;
	}

	public void CopyFrom(T[] arr)
	{
		int arrLength = arr.Length;

		EnsureCapacity(arrLength);

		Array.Copy(arr, array, arrLength);

		count = arrLength;
	}

	public void CopyFrom(FlinqList<T> list)
	{
		int listCount = list.count;

		EnsureCapacity(listCount);
		
		Array.Copy(list.array, 0, array, 0, listCount);

		count = listCount;
	}

	public void CopyFrom(ICollection<T> collection)
	{
		int collectionCount = collection.Count;

		EnsureCapacity(collectionCount);

		collection.CopyTo(array, 0);

		count = collectionCount;
	}

	public void CopyFrom(IEnumerable<T> enumerable)
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

	public void CopyFrom<TKey>(Dictionary<TKey, T> dictionary)
	{
		EnsureCapacity(dictionary.Count);

		count = 0;

		foreach(var elem in dictionary)
		{
			array[count] = elem.Value;
			++count;
		}
	}

	public bool Exists(Predicate<T> predicate)
	{
		return FindIndex(predicate) != -1;
	}

	public T Find(Predicate<T> predicate)
	{
		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			if(predicate(elem))
				return elem;
		}

		return default(T);
	}

	public int FindIndex(Predicate<T> predicate)
	{
		return FindIndex(0, predicate);
	}

	public int FindIndex(int startFrom, Predicate<T> predicate)
	{
		for(int i = startFrom; i < count; ++i)
		{
			var elem = array[i];

			if(predicate(elem))
				return i;
		}

		return -1;
	}

	public T FindLast(Predicate<T> predicate)
	{
		for(int i = count; i >= 0; --i)
		{
			var elem = array[i];

			if(predicate(elem))
				return elem;
		}

		return default(T);
	}

	public int FindLastIndex(Predicate<T> predicate)
	{
		return FindLastIndex(count - 1, predicate);
	}

	public int FindLastIndex(int startFrom, Predicate<T> predicate)
	{
		for(int i = startFrom; i >= 0; --i)
		{
			var elem = array[i];

			if(predicate(elem))
				return i;
		}

		return -1;
	}

	public bool Contains(T elem)
	{
		var comparer = EqualityComparer<T>.Default;

		for(int i = 0; i < count; ++i)
		{
			if(comparer.Equals(array[i], elem))
				return true;
		}

		return false;
	}

	public bool TrueForAll(Predicate<T> predicate)
	{
		for(int i = 0; i < count; ++i)
		{
			if(!predicate(array[i]))
				return false;
		}

		return true;
	}

	public void KeepWhere(Predicate<T> predicate)
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
	
	public void KeepWhere(Func<T, int, bool> predicate)
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

	public void KeepWhereHashSetContains(HashSet<T> hashSet)
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

	public void RemoveWhereHashSetContains(HashSet<T> hashSet)
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
