using Orleans.Runtime;
using System;

namespace Orleans.Indexing
{
    /// <summary>
    /// All the information stored for a single <see cref="IndexWorkflowQueueGrainService"/>
    /// </summary>
    [Serializable, GenerateSerializer]
    internal class IndexWorkflowQueueEntry
    {
        // Updates that must be propagated to indexes.
        internal IndexWorkflowRecordNode WorkflowRecordsHead;

        public IndexWorkflowQueueEntry() => this.WorkflowRecordsHead = null;
    }
}
