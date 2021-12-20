package ssy066.part2;

import ssy066.part1.NotImplementedException;
import ssy066.part1.Operation;
import ssy066.part1.Predicate;
import ssy066.part1.State;

import java.util.*;


public class SearchAGraph {

    /**
     * This method searches a graph for a shortest path to a goal state. The goal
     * state is the state that evaluates the goal predicate to true.
     * <p>
     * Remember that the graph can contain loops, however, if you think about it, maybe this is
     * not a problem when trying to find the shortest path!
     * <p>
     * I have also created a PimpedState class. Use that if you like, to
     * store the state you have visited together with the path to it and its
     * cost.
     *
     * @param g    the graph. Start searching in its initial state. Can contain loops.
     * @param goal the goal that you are searching for
     * @return the SearchResult that includes the shortest path. If no goal is found, return
     * an empty SearchResult
     * REMEMBER: The path always start at the initial state.
     * Maybe you have to do Collections.reverse(list_with_transition_labels)
     */
    public SearchResult findShortestPath(Graph g, Predicate goal) {

        // A tip: Use pimped state when searching instead of only state.
        Deque<PimpedState> que = new ArrayDeque<PimpedState>();

        List<Transition> path = new LinkedList<>();
        PimpedState pimpedState = new PimpedState(g.getInitialState(), path, 0);
        que.add(pimpedState);

        PimpedState pimpedState2;
        List<Transition> pimpPath2;

        while (!que.isEmpty()) {
            Set<PimpedState> visited = new HashSet<PimpedState>();
            pimpedState = que.pollLast();
            visited.add(pimpedState);

            for (Transition t : g.getOutGoingTransitions(pimpedState.state)) {
                if (goal.eval(t.head)) {
                    pimpPath2 = pimpedState.pathToState();
                    pimpPath2.add(t);
                    int cost = pimpedState.cost() + t.cost;
                    pimpedState2 = new PimpedState(t.head, pimpPath2, cost);
                    List<String> bestPath = pimpedState2.labelsToState();
                    Collections.reverse(bestPath);
                    return new SearchResult(bestPath, pimpedState2.cost());
                } else {
                    pimpPath2 = pimpedState.pathToState();
                    pimpPath2.add(t);
                    int cost = pimpedState.cost() + t.cost;
                    pimpedState2 = new PimpedState(t.head, pimpPath2, cost);
                    que.add(pimpedState2);
                }
            }
        }
        throw new NoSuchElementException();
    }


    /**
     * This method searches a graph for the lowest cost path to a goal state. The goal
     * state is the state that evaluates the goal predicate to true.
     * <p>
     * This is trickier compared to the shortest path since we need to search the complete graph. But since
     * there can be loops in the graph, it is important to have a strategy for stopping the search
     * so it does not search forever. Think about when you can stop the search
     *
     * @param g    the graph. Start searching in its initial state. It can contain loops!
     * @param goal the goal that you are searching for
     * @return the SearchResult that includes the lowest cost path
     * and the cost to the lowest cost path. If no goal is found, return
     * an empty SearchResult.
     * REMEMBER: The path you return should always start in the initial state, so
     * maybe you have to do Collections.reverse(list_with_transition_labels) before returning?
     */
    public SearchResult findLowestCostPath(Graph g, Predicate goal) {
        // throw new NotImplementedException();
        // A tip: Use pimped state when searching instead of only state.
        Deque<PimpedState> que = new ArrayDeque<PimpedState>();

        SearchResult shortestResult = findShortestPath(g, goal);

        List<Transition> path = new LinkedList<>();
        PimpedState pimpedState = new PimpedState(g.getInitialState(), path, 0);
        que.add(pimpedState);

        PimpedState pimpedState2;
        List<Transition> pimpPath2;

        while (!que.isEmpty()) {
            pimpedState = que.pollFirst();

            for (Transition t : g.getOutGoingTransitions(pimpedState.state)) {
                if (goal.eval(t.head)) {
                    //if(!pimpedState.state.equals(g.getInitialState())){
                    pimpPath2 = pimpedState.pathToState();
                    pimpPath2.add(t);
                    int cost = pimpedState.cost() + t.cost;
                    pimpedState2 = new PimpedState(t.head, pimpPath2, cost);

                    if (cost < shortestResult.getCostToGoal()) {
                        List<String> cheapestPath = pimpedState2.labelsToState();
                        Collections.reverse(cheapestPath);
                        return new SearchResult(cheapestPath, pimpedState2.cost());
                    } else if (cost > shortestResult.getCostToGoal()) {
                        return shortestResult;
                    }
                }
                pimpPath2 = pimpedState.pathToState();
                pimpPath2.add(t);
                int cost = pimpedState.cost() + t.cost;
                pimpedState2 = new PimpedState(t.head, pimpPath2, cost);
                que.add(pimpedState2);
            }
        }
        throw new NoSuchElementException();

    }
}
