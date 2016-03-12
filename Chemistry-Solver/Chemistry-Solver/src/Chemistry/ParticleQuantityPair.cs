namespace BSmith.Chemistry
{
    /// <summary>
    /// A class representing a partical and its quantity.
    /// </summary>
    /// <typeparam name="TParticle">A partical. Either a Molecule or an Element.</typeparam>
    /// <typeparam name="TQuantity">The quantity of the particle present.</typeparam>
    public class ParticleQuantityPair<TParticle, TQuantity>
    {
        private TParticle particle_;
        public TParticle Particle { get { return particle_; } set { particle_ = value; } }

        private TQuantity quantity_;
        public TQuantity Quantity { get { return quantity_; } set { quantity_ = value; } }

        public ParticleQuantityPair(TParticle particle, TQuantity quantity)
        {
            this.particle_ = particle;
            this.quantity_ = quantity;
        }

        /// <summary>
        /// Converts the partical-quantity pair into a string.
        /// </summary>
        /// <returns>A string representation of the partical-quantity pair.</returns>
        public override string ToString()
        {
            return string.Format("{0}{1}", quantity_, particle_);
        }
    }
}
