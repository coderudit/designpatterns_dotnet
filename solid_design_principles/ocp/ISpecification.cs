namespace solid_design_principles.ocp
{
    internal interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}