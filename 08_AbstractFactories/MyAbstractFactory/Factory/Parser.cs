using System.Collections.Generic;

namespace MyAbstractFactory.Factory
{
    public interface Parser
    {
        // objectは行オブジェクト
        List<object> Parse(string filepath);
    }
}