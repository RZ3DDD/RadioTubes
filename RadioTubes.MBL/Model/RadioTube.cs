namespace RadioTubes.MBL.Model
{
    class RadioTube
    {
        public RadioTube(KindOfTube kindOfTube, int id, KindOfTube tubeKind, string tubeName)
        {
            Id = id;
            TubeKind = tubeKind;
            TubeName = tubeName;
        }

        public int Id { get => default; set => Id = value; }
        public KindOfTube TubeKind { get => TubeKind; set => TubeKind = value; }
        public string TubeName { get; set; }
    }
}
