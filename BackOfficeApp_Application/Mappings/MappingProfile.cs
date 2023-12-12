﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApp_Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        AppplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void AppplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
                            .Where(p => p.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)));
        foreach (var type in types)
        { 
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo.Invoke(instance, new object[] {this});
        }
    }
}
