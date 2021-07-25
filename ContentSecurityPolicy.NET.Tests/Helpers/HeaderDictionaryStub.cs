using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ContentSecurityPolicy.NET.Tests.Helpers
{
    class HeaderDictionaryStub : IHeaderDictionary
    {
        private readonly IDictionary<string, StringValues> dummyDictionary = new Dictionary<string, StringValues>();

        public StringValues this[string key] 
        {
            get => dummyDictionary[key];
            set => dummyDictionary[key] = value; 
        }

        public long? ContentLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<string> Keys => throw new NotImplementedException();

        public ICollection<StringValues> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(string key, StringValues value) => dummyDictionary[key] = value;

        public void Add(KeyValuePair<string, StringValues> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, StringValues> item) => dummyDictionary.Contains(item);

        public bool ContainsKey(string key) => dummyDictionary.ContainsKey(key);

        public void CopyTo(KeyValuePair<string, StringValues>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, StringValues> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out StringValues value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
