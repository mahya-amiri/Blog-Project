import { Switch } from "react-router-dom";
import PanelRoutes from "./PanelRoutes";
import PublicRoutes from "./PublicRoutes";
import AuthRoutes from "./AuthRoutes";
import Route from "./Route";

function Navigation() {
  return (
    <Switch>
      <Route path="/panel/">
        <PanelRoutes />
      </Route>
      <Route path="/auth/">
        <AuthRoutes />
      </Route>
      <Route path="/">
        <PublicRoutes />
      </Route>
    </Switch>
  );
}
export default Navigation;
