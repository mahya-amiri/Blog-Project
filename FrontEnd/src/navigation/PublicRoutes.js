import { Switch } from "react-router-dom";
import Home from "../components/home/Home";
import Categories from "../components/categories/Categories";
import Search from "../components/search/Search";
import About from "../components/other/About";
import Header from "../common/Header";
import Route from "./Route";

function PublicRoutes() {
  return (
    <div>
      {" "}
      <Header title="Home" />
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
    </div>
  );
}
export default PublicRoutes;
