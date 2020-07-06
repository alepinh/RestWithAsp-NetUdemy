using System.Collections.Generic;

namespace RestWithAspNetUdemy.Data.Converter
{
    public interface IParser<O, D>
    {
        D Parse(O origem);
        List<D> ParseList(List<O> origem);

    }
}
