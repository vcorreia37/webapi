using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.Context;

namespace webapi.Models
{
    abstract public class Model<C> where C : class
    {
        protected BbContext _context;

        public Model(BbContext context)
        {
            this._context = context;
        }

        public virtual C Create(C obj)
        {
            _context.Set<C>().Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public virtual void Update(C obj)
        {
            _context.Set<C>().Update(obj);
            _context.SaveChanges();
        }

        public virtual C GetById(int id)
        {
            var obj = _context.Set<C>().Find(id);
            return obj;
        }

        public virtual IEnumerable<C> All()
        {
            return _context.Set<C>();
        }

        public virtual void Delete(int id)
        {
            var obj = _context.Set<C>().Find(id);
            if(obj == null)
            {
                throw new Exception();
            }
            else
            {
                _context.Remove(obj);
                _context.SaveChanges();
            }
        }
    }
}
