package ssy066.part2;

import java.util.*;

import ssy066.part1.*;


public class GraphFactory {


    /**
     * This is a so called factory method. It makes graphs.
     * Creates a Graph based on a set of operations and an initial state. If you divide this method
     * into multiple parts, do not forget to make your methods in this file public static.
     * Remember that you must create your own implementation of the interface Graph
     *
     * @param operations All the operations in the system
     * @param init       The initial state
     * @return The graph
     */
    public static Graph makeMeAGraph(Set<Operation> operations, State init) {
        Graph g = new Graph(init);
        ArrayDeque<State> stack = new ArrayDeque<>();
        Set<State> visited = new HashSet<>();
        stack.push(init);
        Transition trans;
        while (!stack.isEmpty()) {
            State state = stack.pop();
            if (!visited.contains(state)) {
                visited.add(state);
                Set<Operation> ops = enabledOp(operations, state);
                for (Operation o : ops) {
                    trans= makeTransition(o,state);
                    g.addTransition(trans);
                    State nextState = findState(o, state);
                    g.addState(nextState);
                    stack.push(nextState);
                }
            }
        }
        // Implement your graph making code here. Use separate methods for each part and create your
        // unit tests for them. Do not forget to make your methods in this file public static.
        return g;
    }

    public static Set<Operation> enabledOp(Set<Operation> operations, State current) {
        Set<Operation> res = new HashSet<>();
        for (Operation o : operations) {
            if (o.eval(current))
                res.add(o);
        }
        return res;
    }

    public static State findState(Operation operation, State current) {
        return operation.execute(current);

    }
    public static Transition makeTransition(Operation operation, State current){
        Transition trans;
       int  cost= operation.cost();
       String label=operation.name;
       State head= findState(operation,current);
       State tail= current;
       trans=new Transition(label,tail,head,cost);
       return trans;
    }

//xdfcghbjklödfäghjvjhgfdfgd
}