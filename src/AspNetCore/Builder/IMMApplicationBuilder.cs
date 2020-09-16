
using Microsoft.AspNetCore.Builder;

namespace MMFramework.AspNetCore.Builder
{
    public interface IMMApplicationBuilder
    {
        IApplicationBuilder App { get; set; }
        IMMApplicationBuilder UseServiceInfoForPathBase();
        IApplicationBuilder Build();
    }
}