using System.Collections.Generic;
using System.Web.Mvc;
using Snow.Model;
using Snow.Web.ViewModel;
using Snow.Data.Repository;
using Snow.Service;
using AutoMapper;
using System.Linq;

namespace Snow.Web.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IStoreService _StoreService;
        private readonly IInventoryService _InventoryService;
        private readonly IProductService _ProductService;
        private readonly ISizeService _SizeService;

        public InventoryController(IStoreService StoreService, 
                                   IInventoryService InventoryService,
                                   IProductService ProductService,
                                   ISizeService SizeService)
        {
            _StoreService = StoreService;
            _InventoryService = InventoryService;
            _ProductService = ProductService;
            _SizeService = SizeService;
        }

        public ActionResult Index(int? storeId)
        {

            var store = _StoreService.GetStore(1);
            if (store == null)
            {
                return HttpNotFound();
            }

            foreach (var product in store.AllProducts)
            {
                if (product.MyCategory != null)
                    foreach (var size in product.MyCategory.AllSizes)
                    {
                        if (_InventoryService.GetInventory(store, product, size) == null)
                        {
                            var inventoryVM = new InventoryVM();
                            inventoryVM.StoreId = store.Id;
                            inventoryVM.ProductId = product.Id;
                            inventoryVM.SizeId = size.Id;

                            var inventory = Mapper.Map<InventoryVM, Inventory>(inventoryVM);
                            _InventoryService.CreateInventory(inventory);
                            _InventoryService.SaveInventory();
                        }
                    }
                
                
            }

            IEnumerable<InventoryVM> viewModelInventorys;
            IEnumerable<Inventory> Inventorys;

            Inventorys = store.AllInventories.ToList();

            viewModelInventorys = Mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryVM>>(Inventorys);

            return View(viewModelInventorys);
        }

        public ActionResult Details(int id)
        {
            var existing = _InventoryService.GetInventory(id);
            var vmInventory = Mapper.Map<Inventory, InventoryVM>(existing);
            return View(vmInventory);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ICollection<Store> _Stores;
            _Stores = _StoreService.GetStores().ToList();

            ICollection<Product> _Products;
            _Products = _ProductService.GetProducts().ToList();

            ICollection<Size> _Sizes;
            _Sizes = _SizeService.GetSizes().ToList();

            var subscriberVM = new SubscriberVM
            {
                StoresVM = Mapper.Map<ICollection<Store>, ICollection<StoreVM>>(_Stores),
                ProductsVM = Mapper.Map<ICollection<Product>, ICollection<ProductVM>>(_Products),
                SizesVM = Mapper.Map<ICollection<Size>, ICollection<SizeVM>>(_Sizes)
            };

            var InventoryVM = new InventoryVM();
            InventoryVM.MySubscriberVM = subscriberVM;
            return View(InventoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(InventoryVM InventoryVM)
        {
            if (ModelState.IsValid)
            {
                if (InventoryVM != null)
                {
                    var Inventory = Mapper.Map<InventoryVM, Inventory>(InventoryVM);
                    _InventoryService.CreateInventory(Inventory);
                    _InventoryService.SaveInventory();
                }
            }
            return RedirectToAction("Index");
        }
        
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            
            ICollection<Store> _Stores;
            _Stores = _StoreService.GetStores().ToList();

            ICollection<Product> _Products;
            _Products = _ProductService.GetProducts().ToList();

            ICollection<Size> _Sizes;
            _Sizes = _SizeService.GetSizes().ToList();

            var existing = _InventoryService.GetInventory(id);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var InventoryVM = Mapper.Map<Inventory, InventoryVM>(existing);

            var subscriberVM = new SubscriberVM
            {
                StoresVM = Mapper.Map<ICollection<Store>, ICollection<StoreVM>>(_Stores),
                ProductsVM = Mapper.Map<ICollection<Product>, ICollection<ProductVM>>(_Products),
                SizesVM = Mapper.Map<ICollection<Size>, ICollection<SizeVM>>(_Sizes)
            };

            InventoryVM.MySubscriberVM = subscriberVM;
            return View(InventoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(InventoryVM InventoryVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<InventoryVM, Inventory>(InventoryVM);
                _InventoryService.UpdateInventory(existing);
                _InventoryService.SaveInventory();
                return RedirectToAction("Index");
            }
            return View(InventoryVM);
        }
        
        
        /*
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _InventoryService.GetInventory(id);
            var InventoryVM = Mapper.Map<Inventory, InventoryVM>(existing);
            return View(InventoryVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(InventoryVM InventoryVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<InventoryVM, Inventory>(InventoryVM);
                _InventoryService.DeleteInventory(existing);
                _InventoryService.SaveInventory();
                return RedirectToAction("Index");
            }
            return View(InventoryVM);
        }
        */

    }
}