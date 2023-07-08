﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlwaysEast
{
    [Serializable]
    public class EntityStateMachine : ScriptableObject {
        public List<NodeLinkData> NodeLinks = new List<NodeLinkData>();
        public List<InstructionNodeData> InstructionNodeData = new List<InstructionNodeData>();
        public List<ExposedProperty> ExposedProperties = new List<ExposedProperty>();
        public List<CommentBlockData> CommentBlockData = new List<CommentBlockData>();

        public string Advance(string nodeGUID, out List<NodeLinkData> nodeLinks) {
            nodeLinks = NodeLinks.Where(x=>x.NodeGUID == nodeGUID);
            return InstructionNodeData.Find(x=>x.NodeGUID == nodeGUID);
        }
    }
    [Serializable]
    public class InstructionNodeData {
        public string NodeGUID;
        public string Instruction;
        public Vector2 Position;
    }
    [System.Serializable]
    public class ExposedProperty {
        public static ExposedProperty CreateInstance() {
            return new ExposedProperty();
        }
        public string PropertyName = "New String";
        public string PropertyValue = "New Value";
    } 
    [Serializable]
    public class CommentBlockData {
        public List<string> ChildNodes = new List<string>();
        public Vector2 Position;
        public string Title = "Comment Block";
    }
}
