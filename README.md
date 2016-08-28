# About
FLINQ is a LINQ replacement suitable for realtime applications due to object pooling. FLINQ uses immediate execution.

FLINQ usually beats LINQ performance-wise when query's complexity is at least linear (if it's not, then LINQ is much faster due to its deferred execution). In game development, you usually want to iterate over all elements anyway which makes FLINQ a better choice, especially that no memory allocations take place.

FlinqPools.ReturnAllObjects() must be called each frame, or you can define NO_FLINQ_POOLS to disable object pooling.

The project has not beed fully tested yet and may contain bugs.

# FLINQ enumerator

FLINQ query enumerator always enumerates over a copy of the source collection elements (usually no memory allocations take place due to internal object pooling). This means it's perfectly fine to change source collection during enumerating over its elements:

```C#
foreach( var elem in list.AsFlinqQuery() )
{
  list.RemoveAt(0);
}
```

# Operations

FLINQ supports the following operations:
- Aggregate
- All
- Any
- Average
- BuildString
- Contains
- Count
- ElementAt
- ElementAtOrDefault
- First
- FirstOrDefault
- ForEach
- HasDuplicates
- HasDuplicatesBy
- Intersects
- IntersectsBy
- Last
- LastOrDefault
- LongCount
- Max
- MaxBy
- Min
- MinBy
- RandomElement
- RandomElementByWeight
- RandomElementByWeightOrDefault
- RandomElementByWeightOrFirst
- RandomElementOrDefault
- SequenceEqual
- Single
- SingleOrDefault
- Sum
- ToArray
- ToDictionary
- ToEnumerable
- ToList
- Cast
- DistinctBy
- ExceptBy
- GroupBy
- GroupJoin
- Join
- OfType
- OrderBy
- OrderByDescending
- Select
- SelectMany
- Zip
- Appended
- Concat
- DefaultIfEmpty
- Distinct
- Except
- ExistIn
- GetDuplicates
- GetDuplicatesBy
- InRandomOrder
- Intersect
- LazyAppend
- LazyPrepend
- Prepended
- Reversed
- Skip
- SkipWhile
- Take
- TakeWhile
- Union
- UnionLeaveDuplicates
- Where

# Usage notes

- yield return syntax doesn't work with FLINQ
- FlinqPools.ReturnAllObjects() must be called each frame
- FLINQ uses immediate execution, this means that all elements will be iterated over even when running First()
- FLINQ uses object pools which means it will allocate memory only on first use
