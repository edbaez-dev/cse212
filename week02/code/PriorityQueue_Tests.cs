using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities: "low" (1), "high" (5), "medium" (3).
    // Expected Result: Dequeue should return "high" first, since it has the highest priority.
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("medium", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("high", result);
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same highest priority: "first" (5) and "second" (5),
    // plus a lower priority item "low" (1) in between.
    // Expected Result: Dequeue should return "first", since among equal priorities the one
    // closest to the front of the queue (FIFO) is removed first.
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("second", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("first", result);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Call Dequeue on a queue with no items.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue two items, dequeue the highest priority one, then dequeue again.
    // Expected Result: The second Dequeue should return the remaining item, since the first
    // one should have been removed from the queue.
    // Defect(s) Found: Dequeue never removed the item from _queue, so it stayed in the
    // queue and the wrong value was returned on the next Dequeue call.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();

        Assert.AreEqual("high", first);
        Assert.AreEqual("low", second);
    }
}