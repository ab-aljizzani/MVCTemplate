namespace MVCTemplate.Services.AuthorizeServices
{
    public interface IFilterRule<T>
    {
        bool Apply(T item, string role);
    }

}
