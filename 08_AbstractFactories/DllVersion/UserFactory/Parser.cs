using System.Collections.Generic;

namespace UserFactory
{
    public interface Parser
    {
        // objectは行オブジェクト
        List<object> Parse(string filepath);
    }
}