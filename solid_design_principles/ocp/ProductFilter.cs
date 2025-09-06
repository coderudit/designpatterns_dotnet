namespace solid_design_principles.ocp
{
    internal class ProductFilter
    {
        public static IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            /***
            The use of yield return is significant: it allows the method to return matching products one at a time, as they are found, rather than building and returning a complete list all at once. This approach is memory-efficient, especially for large collections, because it enables deferred execution—the caller receives results as they are produced, rather than waiting for the entire filtering process to complete.

            A potential 'gotcha' is that the method containing this code must have a return type compatible with IEnumerable<Product> (or similar), since yield return is only valid in iterator methods. Also, if the products collection is modified during iteration, it could cause runtime errors.
            ***/
            foreach (var p in products)
                if (p.Color == color)
                    yield return p;
        }

        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
                if (p.Size == size)
                    yield return p;
        }

        public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var p in products)
                if (p.Size == size && p.Color == color)
                    yield return p;
        }
    }
}