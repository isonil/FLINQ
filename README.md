# About
FLINQ is a LINQ replacement suitable for realtime applications due to object pooling. FLINQ uses immediate execution.

FLINQ usually beats LINQ performance-wise when query's complexity is at least linear (if it's not, then LINQ is much faster due to its deferred execution). In game development, you usually want to iterate over all elements anyway which makes FLINQ a better choice, especially that no memory allocations take place.

FlinqPools.ReturnAllObjects() must be called each frame, or you can define NO_FLINQ_POOLS to disable object pooling.

The project is not finished yet and may contain bugs.

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
- Append
- Concat
- DefaultIfEmpty
- Distinct
- Except
- ExistIn
- GetDuplicates
- InRandomOrder
- Intersect
- LazyAppend
- LazyPrepend
- Prepend
- Reverse
- Skip
- SkipWhile
- Take
- TakeWhile
- Union
- UnionLeaveDuplicates
- Where

# Usage

- FlinqQuery<T> is like a IEnumerable<T> in LINQ
- yield return syntax doesn't work with FLINQ
- FlinqPools.ReturnAllObjects() must be called each frame
