import { Switch, Route } from "react-router-dom";
import Home from "../components/home/Home";
import Categories from "../components/categories/Categories";
import Search from "../components/search/Search";
import About from "../components/other/About";

function Navigation() {
  return (
    <Switch>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/categories">
        <Categories />
      </Route>
      <Route path="/search">
        <Search />
      </Route>
      <Route path="/about">
        <About />
      </Route>
    </Switch>
  );
}
export default Navigation;
