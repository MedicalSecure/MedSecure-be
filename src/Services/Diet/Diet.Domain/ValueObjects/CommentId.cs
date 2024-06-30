using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Domain.ValueObjects
{
        public record CommentId
    {
        private CommentId() { }

        public Guid Value { get; }

        private CommentId(Guid value) => Value = value;

        public static CommentId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("BPModelId cannot be empty!");
            }
            return new CommentId(value);
        }
    }

}
