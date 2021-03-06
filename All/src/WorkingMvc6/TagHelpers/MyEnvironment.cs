﻿using System.Linq;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Razor.TagHelpers;
using Microsoft.Extensions.PlatformAbstractions;

namespace WorkingMvc6.TagHelpers
{
    [HtmlTargetElement("my-environment")]
    public class MyEnvironment : TagHelper
    {
        private readonly IHostingEnvironment _env;

        public MyEnvironment(IHostingEnvironment env)
        {
            _env = env;
        }

        public string Names { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Names.Split().Any(n => _env.EnvironmentName == n))
            {
                return;
            }

            output.SuppressOutput();
        }
    }
}