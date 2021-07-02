# About
FLINQ is a LINQ replacement suitable for realtime applications thanks to object pooling. FLINQ only supports immediate execution.

FLINQ usually beats LINQ performance-wise if the query's complexity is at least linear (if it's not, then LINQ is much faster because of  its deferred execution). In game development, in most cases you want to iterate over all the elements anyway which makes FLINQ a better choice, especially that no memory allocations take place.

FlinqPools.ReturnAllObjects() must be called each frame, or you can define NO_FLINQ_POOLS to disable object pooling.

The project has not been fully tested yet and may contain bugs.

# FLINQ enumerator

FLINQ query enumerator always enumerates over a copy of the source collection elements (usually no memory allocations take place due to internal object pooling). This means it's perfectly fine to change source collection while enumerating over its elements:

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

- yield return syntax is not supported
- FlinqPools.ReturnAllObjects() must be called every frame
- FLINQ only supports immediate execution which means that all elements will be iterated over even if First() is called
- FLINQ uses object pools which means it will allocate memory only on first use
