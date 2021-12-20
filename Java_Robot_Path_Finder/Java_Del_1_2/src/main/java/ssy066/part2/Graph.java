package ssy066.part2;

import ssy066.part1.NotImplementedException;
import ssy066.part1.Operation;
import ssy066.part1.State;

import java.util.*;

/**
 * This is the Graph class that you need to implement. It is used when creating a graph
 * and will be used when navigating the graph. Your task is to create new methods for adding new states
 * and transitions as well as decide how the graph should be represented internally in this class. You
 * can store all states and transitions explicitly or use a more compact representation.
 *
 * Read more about graph representation in this great article by Vaidehi Joshi:
 * https://medium.com/basecs/from-theory-to-practice-representing-graphs-cfd782c5be38
 *
 * Observe that this class should not know anything about operations or store operations internally
 *
 *
 */
public class Graph {

    private State initial;
    private HashSet<State> Q = new HashSet<>();
    private HashSet<Transition>T = new HashSet<>();

    /**
     * This is the constructor that creates an empty Graph with only one initial state.
     * The method is already defined and you do not need to change it.
     */
    public Graph(State initial) {
        this.initial = initial;
        this.Q.add(initial);
    }

    /**
     * Returns the initial state. You do not need to change this.
     *
     * @return the initial state of this graph
     */
    public State getInitialState() {
        return initial;
    }



    // *************************
    // Below, you should add methods to fill the graph with states and transitions.
    // You can add one thing at the time (or all at ones).
    // Do not forget to add unit tests to test all your methods
    // *************************
    public void addState(State state){
            Q.add(state);
    }
    public void addTransition(Transition transition) {
        if (!T.contains(transition))
            T.add(transition);
    }






        // *************************
    // Below, you should implement the methods.
    // Do not forget to add unit tests to test all your methods
    // *************************


    /**
     * This functions should return all states that this graph represent. Depending on your
     * internal representation, this may need to compute all possible states
     *
     * It should not be possible to add states to the graph by changing the returned set.
     *
     * @return a set of all states in this graph.
     */
    public HashSet<State> getStates() {
        return Q;
    }

    /**
     * This functions should return all transitions that this graph represent. Depending on your
     * internal representation, this may need to compute all possible transitions and create
     * Transition objects and return.
     *
     * It should not be possible to add transitions to the graph by changing the returned set.
     *
     * @return a set of all transitions of this graph
     */
    public HashSet<Transition> getTransitions() {
       return T;//return new hash set
    }



    /**
     * Given a state, returns all outgoing transitions from this state, i.e. all transition where
     * the state is a tail.
     *
     * @param s The state
     * @return All outgoing transitions
     */
    public HashSet<Transition> getOutGoingTransitions(State s) {
        HashSet<Transition> res = new HashSet<>();
        for(Transition t: T){
            if(t.tail.equals(s))res.add(t);
        }
        return res;
    }

    /**
     * Given a state, return all transitions coming into that state, i.e. all transitions where
     * the state is head
     *
     * @param s the state
     * @return a set including the incoming transitions
     */
    public HashSet<Transition> getIncomingTransitions(State s) {
        HashSet<Transition> res = new HashSet<>();
        for(Transition t: T){
          if(t.head.equals(s))res.add(t);
        }
        return res;
    }

    /**
     * Returns all states that does not have any incoming transitions
     * @return A set of states
     */
    public HashSet<State> getSourceStates() {
        HashSet<State> res = new HashSet<>();
        for(State q: Q){
            if(this.getIncomingTransitions(q).isEmpty())
                res.add(q);
        }
        return res;
    }

    /**
     * Returns all states that does not have any outgoing transitions
     * @return A set of states
     */
    public HashSet<State> getSinkStates() {
        HashSet<State> res = new HashSet<>();
        for(State q: Q){
            if(getOutGoingTransitions(q).isEmpty())
                res.add(q);
        }
        return res;

    }



}
