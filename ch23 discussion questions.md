# Chapter 23. Discussion Questions
## Kenneth Clark
### December 8, 2017  

1.  List two reasons for multitasking and explain the rationale for them.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** The two reasons for multitasking are to improve responsiveness and to improve scalability. To improve responsiveness means to increase the amount of operations that a system could be doing at a time versus standing by and waiting for one task to be completed before performing another. To improve scalability means to make efficient use of the processing resources available and determining which operations could be performed with others versus the operations that could be performed by themselves.

2.  Explain Moore’s law.  What does Moore’s law have to do with multitasking?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:**  Moore’s Law is a statement from Gordon E. Moore that states that the number of transistors that can be placed inexpensively on an integrated circuit will increase exponentially, doubling approximately every two years.  Moore’s Law goes with the idea of multitasking by contributing to the rationale of improving scalability.  It introduces the ability to pack transistors together to improve the ability to pass data between them more quickly. 

3.  In UWP, what namespace is used as the container for the multitasking methods?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:**  The Task class and a collection of associated types in the System.Threading.Tasks namespace.

4.  What is the difference between tasks and threads? Explain.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** Tasks are the degree of parallelization in an application and threads are the units of parallelization.  On a single-processor computer these items are the same but on a computer with multiple processors they are different.

5.  What is the ThreadPool?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:**  It is a class that implements a number of optimizations and uses a work-stealing algorithm to ensure that threads are scheduled efficiently.

6.  What parameters does the Task() constructor take?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:**  The Task() constructor takes an Action delegate as a parameter.

7.  How do you start a thread?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:**  By using the Start () method.  For example;  task.start()

8.  What is the difference between the Start() and Run() methods?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:**  The Start () method is used to set up and schedule how to run tasks.  The Run() method takes an Action delegate that specifies the operation to perform and starts the task running immediately.

9.  What is the difference between creating independent tasks with Tasks and parallelization with Parallel?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:**  Parallelization is when it runs multiple tasks at once and independent tasks are a manual way to run tasks on your own. 

10.  Explain how manual cancellation works using a cancellation token.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** A cancellation token is a structure that represents a request to cancel one or more tasks. The method that a task runs should include a System.Threading.CancellationToken parameter. An application that wants to cancel the task sets the Boolean IsCancellationRequested property of this parameter to true. The method running in the task can query this property at various points during its processing. If this property is set to true at any point, it knows that the application has requested that the task be canceled. 