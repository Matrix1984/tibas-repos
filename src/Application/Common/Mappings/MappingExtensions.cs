﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Tibas.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Tibas.Application.Common.Mappings;

public static class MappingExtensions
{  
    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
        => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
}
