using deployment.Models.Regions;
using Piranha.AttributeBuilder;
using Piranha.Models;

namespace deployment.Models
{
    [PageType(Title = "Blog archive", UseBlocks = false)]
    public class BlogArchive  : ArchivePage<BlogArchive>
    {
        /// <summary>
        /// Gets/sets the archive hero.
        /// </summary>
        [Region]
        public Hero Hero { get; set; }
    }
}