import { Switch } from "react-router-dom";
import Route from "./Route";
import PanelLayout from "../components/panel/layout/Layout";
import Users from "../components/panel/users/Users";
import CreateUser from "../components/panel/users/CreateUser";
import EditUser from "../components/panel/users/EditUser";
import Categories from "../components/panel/categories/Categories";
import CreateCategory from "../components/panel/categories/CreateCategory";
import Articles from "../components/panel/articles/Articles";
import CreateArticle from "../components/panel/articles/CreateArticle";

function PanelRoutes() {
  return (
    <PanelLayout>
      <Switch>
        <Route exact path="/panel/users">
          <Users />
        </Route>
        <Route exact path="/panel/users/create">
          <CreateUser />
        </Route>
        <Route exact path="/panel/users/:id/edit">
          <EditUser />
        </Route>
        <Route exact path="/panel/categories">
          <Categories />
        </Route>
        <Route exact path="/panel/categories/create">
          <CreateCategory />
        </Route>
        <Route exact path="/panel/articles">
          <Articles />
        </Route>
        <Route exact path="/panel/articles/create">
          <CreateArticle />
        </Route>
      </Switch>
    </PanelLayout>
  );
}

export default PanelRoutes;
