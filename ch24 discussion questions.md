# Chapter 24. Discussion Questions
## Kenneth Clark
### December 8, 2017  

1. What is an asynchronous method? When the book talks about a contract, what is the contract and
who is it with?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** An asynchronous method is one that does not block the current thread on which it starts to run.  The contract that the book talks about is an implied contract that expects the method to return control to the calling environment quite quickly and to perform its work on a separate thread. 

2. What can be the problem with decomposing a series of discrete method calls into a set of tasks, such
as we saw in chapter 23?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** A problem with decomposing a series of discrete method calls into a set of tasks is that some method calls rely on information in the other method calls that haven't completed yet.

3. What can be the problem with decomposing a series of discrete method calls into a set of continuations? When does the last continuation \complete" as compared to the previous continuations? What problem might this cause?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** When decomposing a series of discrete method calls into a set of continuations, one problem can be that the signatures of the methods have to change to accommodate the requirements of continuations (the Task object that instigated the continuation is passed as a parameter to a continuation method). The last continuation completes after the previous continuations. 

4. What might be the problem with implementing the previous solution as a continuation passing a dele-
gate? What would be your interpretation with this error message: \The application called an interface
that was marshaled for a different thread."?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** When decomposing a series of discrete method calls into a set of continuations there is the possibility that the final continuation generates a System.Exception exception with the rather obscure message, “The application called an interface that was marshaled for a different thread.” This can happen if your task is trying to access information in another thread.

5. The book suggests a solution using a continuation delegate calling another continuation delegate via
an anonymous function. What does the book identify as a problem with this suggested solution?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** The problem the book identifies is if the code is run in Debug mode the final continuation generates a System.Exception exception with rather obscure message, “The application called an interface that was marshaled for a different thread.”

6. What does the async modifier do? What does the await operator do?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:**  The async modifier indicates that a method contains functionality that can be run asynchronously.  The await operator specifies the point at which this asynchronous functionality should be performed.

7. What is an awaitable object? Be specific.

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:**  The awaitable object is a type that provides the GetAwaiter method, which returns an object that in turn provides methods for running code and waiting for it to complete.

8. In a method definition, how do you create and run a Task and return a reference to the Task? What
is the type of such a method? What does the method return?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** Inside the method, you create and run the task using Task mytask = Task.Run(() => { /* code for the task */ });. You would then return the task like any other variable: return mytask;.

9. How do you define method calls in the implementation of an async method? Specifically, you must
define a task, you must run the task, you must implement the task, and you must await the task.
What is the syntax for doing this?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** Task mytask = Task.Run(() => { /* code for the task */ });
await mytask;


10. What is the difference between decomposing a series of method calls that do not return values, and
a series of method calls that return values? What is the Result property of a method that returns a
value? How do you use the await operator in this circumstance?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** The difference is that the method calls that return values have values to return. To do this, you use the generic Task<TResult> class, where the type parameter, TResult, specifies the type of the result. The await operator extracts the value from the Task returned by the method, and in this case assigns it to the result variable.

11. What is the difference between the await operator and the Wait method?

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**Answer:** The await operator is not the same as using the Wait method of a task. The Wait method always blocks the current thread and does not allow it to be reused until the task completes.

