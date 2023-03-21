﻿namespace MultiplayerARPG
{
    [System.Serializable]
    public partial struct BuildingSaveData : IBuildingSaveData
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public int EntityId { get; set; }
        public int CurrentHp { get; set; }
        public float RemainsLifeTime { get; set; }
        public bool IsLocked { get; set; }
        public string LockPassword { get; set; }
        public Vec3 Position { get; set; }
        public Vec3 Rotation { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string ExtraData { get; set; }
    }
}
