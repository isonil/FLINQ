# About
LINQ replacement suitable for realtime applications due to object pooling. FLINQ uses immediate execution.

FLINQ usually beats LINQ performance-wise when query's complexity is at least linear (if it's not, then LINQ's deferred execution makes LINQ much faster). In game development, you usually want to iterate over all elements anyway which makes FLINQ a better choice, especially that no memory allocs take place.

The project is not finished yet and may contain bugs.
