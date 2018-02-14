/* SystemJS module definition */
declare var module: NodeModule;
interface NodeModule {
  id: string;
}
declare function require(moduleName: string): any;
