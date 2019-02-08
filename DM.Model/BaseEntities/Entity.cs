using System;
using System.Collections.Generic;
using DM.Model.Interfaces;
using System.Linq;

namespace DM.Model
{
    public class Entity: IEntity, ICachekey
    {
        public Guid Id { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual int CacheKey => $"{Id}".GetHashCode();
    }

    public class TenantAwareEntity : Entity
    {
        public Guid TenantId { get; set; }
        public override int CacheKey => $"{Id}-{TenantId}".GetHashCode();
    }

    public class TranslationEntity : Entity
    {
        public string Locale { get; set; }
        public override int CacheKey => $"{Id}-{Locale}".GetHashCode();
    }

    
    public static class EnumberableExtensions
    {
        public static long GetCacheKey<T>(this IEnumerable<T> list)
        {
            return string.Join("-", list.Select(l => (l as ICachekey)?.CacheKey)).GetHashCode();
        }
    }
}