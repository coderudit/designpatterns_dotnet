namespace solid_design_principles.ocp
{
    internal interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
}