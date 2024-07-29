﻿using Domain.Model;

namespace Core.Repository
{
    public interface IAuthorRepository
    {
        Author? Get(int authorId);

        Task<Author> AddAsync(Author author);

        Task<Author> UpdateAsync(Author author);

        Task RemoveAsync(int authorId);

        Task<IEnumerable<Author>> GetAsync();
    }
}
