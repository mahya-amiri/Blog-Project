import { Switch } from "react-router-dom";
import PanelLayout from "../components/panel/layout/Layout";
import Users from "../components/panel/users/Users";
import CreateUser from "../components/panel/users/CreateUser";
import EditUser from "../components/panel/users/EditUser";
import Route from "./Route";

function PanelRoutes() {
  return (
    <PanelLayout>
      <Switch>
        <Route exact path="/panel/users">
          <Users></Users>
        </Route>
        <Route exact path="/panel/users/create">
          <CreateUser></CreateUser>
        </Route>
        <Route exact path="/panel/users/:id/edit">
          <EditUser />
        </Route>
      </Switch>
    </PanelLayout>
  );
}
export default PanelRoutes;
