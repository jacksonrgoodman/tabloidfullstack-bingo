﻿using System.Collections.Generic;
using Tabloid.Models;

namespace Tabloid.Repositories
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        void Delete(int id);
        List<Comment> GetCommentsByPostId(int id);
        void Update(Comment comment);
    }
}