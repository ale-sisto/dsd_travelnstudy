namespace StudyAbroad.DomainModel.Framework
{
    public abstract class DomainBase<T> where T: DomainBase<T>
    {
        private int? _oldHashCode;

        public virtual int Id { get; set; }

        public override bool Equals(object obj)
        {
            var objectForComparison = obj as T;
            if (objectForComparison == null) return false;

            var objectIsNew = Equals(Id, 0);
            var objectForComparisonIsNew = Equals(objectForComparison.Id, 0);

            if (objectIsNew && objectForComparisonIsNew)
                return ReferenceEquals(this, objectForComparison);

            return Id.Equals(objectForComparison.Id);
        }

        public override int GetHashCode()
        {
            if (_oldHashCode.HasValue)
                return _oldHashCode.Value;

            var objectIsNew = Equals(Id, 0);
            if (objectIsNew)
            {
                _oldHashCode = base.GetHashCode();
                return _oldHashCode.Value;
            }

            return Id.GetHashCode();
        }

        public static bool operator ==(DomainBase<T> x, DomainBase<T> y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(DomainBase<T> x, DomainBase<T> y)
        {
            return !Equals(x, y);
        }
    }
}
