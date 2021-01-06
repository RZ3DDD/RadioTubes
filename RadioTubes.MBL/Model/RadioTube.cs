using System.Threading;

namespace RadioTubes.MBL.Model
{
    class RadioTube : RadioComponent
    {
        static int nextId;
        public RadioTube(KindOfTube tubeKind, string tubeName)
        {
            Id = Interlocked.Increment(ref nextId);
            TubeKind = tubeKind;
            TubeName = tubeName;
        }

        public int Id { get => default; set => Id = value; }
        public KindOfTube TubeKind { get => TubeKind; set => TubeKind = value; }
        public string TubeName { get; set; }
    }
}
