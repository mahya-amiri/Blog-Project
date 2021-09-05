import { Switch } from "react-router-dom";
import PanelRoutes from "./PanelRoutes";
import PublicRoutes from "./PublicRoutes";
import AuthRoutes from "./AuthRoutes";
import Route from "./Route";

function Navigation() {
  return (
    <Switch>
      <Route admin path="/panel/">
        <PanelRoutes />
      </Route>
      <Route guest path="/auth/">
        <AuthRoutes />
      </Route>
      <Route path="/">
        <PublicRoutes />
      </Route>
    </Switch>
  );
}
export default Navigation;
